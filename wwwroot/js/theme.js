window.blazorTheme = {
    storageKey: 'btui-theme-mode',
    accentKey: 'btui-theme-accent',
    customHexKey: 'btui-theme-custom-hex',
    dotNetHelper: null,
    mediaQuery: null,
    mediaListener: null,

    hexToRgb: function (hex) {
        let clean = hex.replace('#', '').trim();
        if (clean.length === 3) {
            clean = clean.split('').map(c => c + c).join('');
        }
        if (clean.length !== 6) return null;
        const num = parseInt(clean, 16);
        return {
            r: (num >> 16) & 255,
            g: (num >> 8) & 255,
            b: num & 255
        };
    },

    applyCustomShades: function (hex) {
        const rgb = this.hexToRgb(hex);
        if (!rgb) return;
        const root = document.documentElement;

        const mixWhite = (val, factor) => Math.round(val * (1 - factor) + 255 * factor);
        const mixBlack = (val, factor) => Math.round(val * factor);

        const s50 = `${mixWhite(rgb.r, 0.92)} ${mixWhite(rgb.g, 0.92)} ${mixWhite(rgb.b, 0.92)}`;
        const s100 = `${mixWhite(rgb.r, 0.82)} ${mixWhite(rgb.g, 0.82)} ${mixWhite(rgb.b, 0.82)}`;
        const s200 = `${mixWhite(rgb.r, 0.65)} ${mixWhite(rgb.g, 0.65)} ${mixWhite(rgb.b, 0.65)}`;
        const s300 = `${mixWhite(rgb.r, 0.45)} ${mixWhite(rgb.g, 0.45)} ${mixWhite(rgb.b, 0.45)}`;
        const s400 = `${mixWhite(rgb.r, 0.25)} ${mixWhite(rgb.g, 0.25)} ${mixWhite(rgb.b, 0.25)}`;
        const s500 = `${rgb.r} ${rgb.g} ${rgb.b}`;
        const s600 = `${mixBlack(rgb.r, 0.85)} ${mixBlack(rgb.g, 0.85)} ${mixBlack(rgb.b, 0.85)}`;
        const s700 = `${mixBlack(rgb.r, 0.72)} ${mixBlack(rgb.g, 0.72)} ${mixBlack(rgb.b, 0.72)}`;

        root.style.setProperty('--color-brand-50', s50);
        root.style.setProperty('--color-brand-100', s100);
        root.style.setProperty('--color-brand-200', s200);
        root.style.setProperty('--color-brand-300', s300);
        root.style.setProperty('--color-brand-400', s400);
        root.style.setProperty('--color-brand-500', s500);
        root.style.setProperty('--color-brand-600', s600);
        root.style.setProperty('--color-brand-700', s700);
        root.setAttribute('data-accent', 'custom');
    },

    clearCustomShades: function () {
        const root = document.documentElement;
        root.style.removeProperty('--color-brand-50');
        root.style.removeProperty('--color-brand-100');
        root.style.removeProperty('--color-brand-200');
        root.style.removeProperty('--color-brand-300');
        root.style.removeProperty('--color-brand-400');
        root.style.removeProperty('--color-brand-500');
        root.style.removeProperty('--color-brand-600');
        root.style.removeProperty('--color-brand-700');
    },

    init: function (dotNetRef) {
        this.dotNetHelper = dotNetRef;
        const urlParams = new URLSearchParams(window.location.search);
        const queryTheme = urlParams.get('theme');
        const queryAccent = urlParams.get('accent');
        const mode = queryTheme || localStorage.getItem(this.storageKey) || 'system';
        const accent = queryAccent || localStorage.getItem(this.accentKey) || 'indigo';
        const customHex = localStorage.getItem(this.customHexKey);

        this.applyTheme(mode);

        if (accent === 'custom' && customHex) {
            this.applyCustomShades(customHex);
        } else {
            this.clearCustomShades();
            this.applyAccent(accent);
        }

        if (!this.mediaQuery) {
            this.mediaQuery = window.matchMedia('(prefers-color-scheme: dark)');
            this.mediaListener = (e) => {
                const currentMode = localStorage.getItem(this.storageKey) || 'system';
                if (currentMode === 'system') {
                    this.updateDomClass(e.matches);
                    if (this.dotNetHelper) {
                        this.dotNetHelper.invokeMethodAsync('OnSystemThemeChanged', e.matches);
                    }
                }
            };
            this.mediaQuery.addEventListener('change', this.mediaListener);
        }

        return {
            mode: mode,
            accent: accent,
            customHex: accent === 'custom' ? customHex : null,
            isDark: document.documentElement.classList.contains('dark')
        };
    },

    setMode: function (mode) {
        localStorage.setItem(this.storageKey, mode);
        return this.applyTheme(mode);
    },

    setAccent: function (accent) {
        this.clearCustomShades();
        localStorage.removeItem(this.customHexKey);
        localStorage.setItem(this.accentKey, accent);
        this.applyAccent(accent);
    },

    setCustomAccent: function (hex) {
        if (!hex) return;
        localStorage.setItem(this.accentKey, 'custom');
        localStorage.setItem(this.customHexKey, hex);
        this.applyCustomShades(hex);
    },

    applyTheme: function (mode) {
        let isDark = false;
        if (mode === 'dark') {
            isDark = true;
        } else if (mode === 'light') {
            isDark = false;
        } else {
            isDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        }
        this.updateDomClass(isDark);
        return isDark;
    },

    applyAccent: function (accent) {
        document.documentElement.setAttribute('data-accent', accent || 'indigo');
    },

    updateDomClass: function (isDark) {
        const root = document.documentElement;
        if (isDark) {
            root.classList.add('dark');
        } else {
            root.classList.remove('dark');
        }
    },

    dispose: function () {
        if (this.mediaQuery && this.mediaListener) {
            this.mediaQuery.removeEventListener('change', this.mediaListener);
        }
        if (this.scrollHandler) {
            window.removeEventListener('scroll', this.scrollHandler);
            this.scrollHandler = null;
        }
        this.dotNetHelper = null;
        this.scrollDotNetHelper = null;
    },

    scrollToTop: function (smooth = true) {
        window.scrollTo({
            top: 0,
            left: 0,
            behavior: smooth ? 'smooth' : 'auto'
        });
    },

    registerScrollListener: function (dotNetHelper, threshold) {
        this.scrollDotNetHelper = dotNetHelper;
        this.scrollThreshold = threshold || 150;
        if (!this.scrollHandler) {
            this.scrollHandler = () => {
                const y = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
                const isVisible = y > (this.scrollThreshold || 150);
                const totalHeight = document.documentElement.scrollHeight - document.documentElement.clientHeight;
                const progress = totalHeight > 0 ? Math.min(100, Math.round((y / totalHeight) * 100)) : 0;
                if (this.scrollDotNetHelper) {
                    this.scrollDotNetHelper.invokeMethodAsync('OnScrollChanged', isVisible, progress);
                }
            };
            window.addEventListener('scroll', this.scrollHandler, { passive: true });
        }
        // Fire immediately
        this.scrollHandler();
    },

    unregisterScrollListener: function () {
        this.scrollDotNetHelper = null;
    }
};

window.blazorTailwind = {
    paletteHelper: null,
    paletteListenerAttached: false,

    initCommandPaletteListener: function (dotNetHelper) {
        this.paletteHelper = dotNetHelper;
        if (!this.paletteListenerAttached) {
            window.addEventListener('keydown', (e) => {
                if ((e.ctrlKey || e.metaKey) && (e.key === 'k' || e.key === 'K')) {
                    e.preventDefault();
                    if (this.paletteHelper) {
                        this.paletteHelper.invokeMethodAsync('TogglePaletteFromShortcut');
                    }
                }
            });
            this.paletteListenerAttached = true;
        }
    },

    copyToClipboard: async function (text) {
        try {
            if (navigator.clipboard && navigator.clipboard.writeText) {
                await navigator.clipboard.writeText(text);
                return true;
            }
            const textArea = document.createElement("textarea");
            textArea.value = text;
            textArea.style.position = "fixed";
            textArea.style.left = "-999999px";
            document.body.appendChild(textArea);
            textArea.select();
            document.execCommand('copy');
            document.body.removeChild(textArea);
            return true;
        } catch (err) {
            console.error('Failed to copy to clipboard:', err);
            return false;
        }
    },

    initSpotlightTracker: function (element) {
        if (!element) return;
        element.addEventListener('mousemove', (e) => {
            const rect = element.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;
            element.style.setProperty('--mouse-x', `${x}px`);
            element.style.setProperty('--mouse-y', `${y}px`);
        });
    }
};

window.blazorMediaPlayer = {
    init: function (mediaEl, dotNetRef) {
        if (!mediaEl || !dotNetRef) return;

        const updateState = () => {
            let bufferedEnd = 0;
            if (mediaEl.buffered && mediaEl.buffered.length > 0) {
                bufferedEnd = mediaEl.buffered.end(mediaEl.buffered.length - 1);
            }
            dotNetRef.invokeMethodAsync('OnMediaStateUpdate', {
                currentTime: mediaEl.currentTime || 0,
                duration: mediaEl.duration || 0,
                paused: mediaEl.paused,
                muted: mediaEl.muted,
                volume: mediaEl.volume,
                playbackRate: mediaEl.playbackRate,
                bufferedEnd: bufferedEnd,
                ended: mediaEl.ended
            }).catch(() => {});
        };

        mediaEl.addEventListener('timeupdate', updateState);
        mediaEl.addEventListener('durationchange', updateState);
        mediaEl.addEventListener('play', updateState);
        mediaEl.addEventListener('pause', updateState);
        mediaEl.addEventListener('ended', updateState);
        mediaEl.addEventListener('volumechange', updateState);
        mediaEl.addEventListener('progress', updateState);
        mediaEl.addEventListener('loadedmetadata', updateState);

        // Fire once immediately
        updateState();
    },

    play: function (mediaEl) {
        if (mediaEl && mediaEl.play) {
            mediaEl.play().catch(e => console.warn('Play prevented:', e));
        }
    },

    pause: function (mediaEl) {
        if (mediaEl && mediaEl.pause) {
            mediaEl.pause();
        }
    },

    setCurrentTime: function (mediaEl, time) {
        if (mediaEl) {
            mediaEl.currentTime = time;
        }
    },

    seekFromEvent: function (mediaEl, trackEl, clientX) {
        if (!mediaEl || !trackEl) return;
        const rect = trackEl.getBoundingClientRect();
        if (rect.width <= 0) return;
        const ratio = Math.max(0, Math.min(1, (clientX - rect.left) / rect.width));
        const duration = mediaEl.duration || 0;
        if (duration > 0) {
            mediaEl.currentTime = ratio * duration;
        }
    },

    setVolume: function (mediaEl, vol) {
        if (mediaEl) {
            mediaEl.volume = Math.max(0, Math.min(1, vol));
            mediaEl.muted = vol === 0;
        }
    },

    setMuted: function (mediaEl, muted) {
        if (mediaEl) {
            mediaEl.muted = muted;
        }
    },

    setPlaybackRate: function (mediaEl, rate) {
        if (mediaEl) {
            mediaEl.playbackRate = rate;
        }
    },

    toggleFullscreen: function (containerEl) {
        if (!containerEl) return;
        if (!document.fullscreenElement) {
            if (containerEl.requestFullscreen) {
                containerEl.requestFullscreen().catch(() => {});
            }
        } else {
            if (document.exitFullscreen) {
                document.exitFullscreen().catch(() => {});
            }
        }
    },

    togglePiP: async function (videoEl) {
        if (!videoEl) return false;
        try {
            if (document.pictureInPictureElement) {
                await document.exitPictureInPicture();
                return false;
            } else if (videoEl.requestPictureInPicture) {
                await videoEl.requestPictureInPicture();
                return true;
            }
        } catch (e) {
            console.warn('PiP error:', e);
        }
        return false;
    }
};

window.blazorBarcodeScanner = {
    codeReader: null,
    activeStream: null,
    currentTrack: null,
    torchOn: false,

    initReader: function () {
        if (!this.codeReader && window.ZXing) {
            this.codeReader = new window.ZXing.BrowserMultiFormatReader();
        }
        return !!this.codeReader;
    },

    getVideoInputDevices: async function () {
        this.initReader();
        if (!this.codeReader) return [];
        try {
            const devices = await this.codeReader.listVideoInputDevices();
            return (devices || []).map(d => ({ deviceId: d.deviceId, label: d.label || `Camera ${d.deviceId.slice(0, 5)}` }));
        } catch (e) {
            console.warn('Cannot list video devices:', e);
            return [];
        }
    },

    startCamera: async function (videoEl, deviceId, dotNetHelper) {
        this.initReader();
        if (!this.codeReader || !videoEl) return false;

        try {
            this.stopCamera();

            this.codeReader.decodeFromVideoDevice(deviceId || undefined, videoEl, (result, err) => {
                if (result) {
                    this.playScanBeep();
                    dotNetHelper.invokeMethodAsync('OnBarcodeDetected', {
                        text: result.getText(),
                        format: result.getBarcodeFormat() ? result.getBarcodeFormat().toString() : 'QR_CODE',
                        timestamp: new Date().toISOString()
                    }).catch(() => {});
                }
            });

            setTimeout(() => {
                if (videoEl.srcObject && videoEl.srcObject.getVideoTracks) {
                    const tracks = videoEl.srcObject.getVideoTracks();
                    if (tracks.length > 0) {
                        this.currentTrack = tracks[0];
                    }
                }
            }, 800);

            return true;
        } catch (e) {
            console.error('Failed to start camera:', e);
            return false;
        }
    },

    stopCamera: function () {
        if (this.codeReader) {
            try {
                this.codeReader.reset();
            } catch (e) {}
        }
        if (this.currentTrack) {
            try {
                this.currentTrack.stop();
            } catch (e) {}
            this.currentTrack = null;
        }
        this.torchOn = false;
    },

    toggleTorch: async function () {
        if (!this.currentTrack) return false;
        try {
            const capabilities = this.currentTrack.getCapabilities ? this.currentTrack.getCapabilities() : {};
            if (capabilities.torch) {
                this.torchOn = !this.torchOn;
                await this.currentTrack.applyConstraints({
                    advanced: [{ torch: this.torchOn }]
                });
                return this.torchOn;
            }
        } catch (e) {
            console.warn('Torch not supported or failed:', e);
        }
        return false;
    },

    decodeDataUrl: async function (dataUrl) {
        this.initReader();
        if (!this.codeReader || !dataUrl) return null;
        return new Promise((resolve) => {
            const img = new Image();
            img.onload = async () => {
                try {
                    const result = await this.codeReader.decodeFromImageElement(img);
                    if (result) {
                        this.playScanBeep();
                        resolve({
                            text: result.getText(),
                            format: result.getBarcodeFormat() ? result.getBarcodeFormat().toString() : 'QR_CODE',
                            timestamp: new Date().toISOString()
                        });
                        return;
                    }
                } catch (e) {}
                resolve(null);
            };
            img.onerror = () => resolve(null);
            img.src = dataUrl;
        });
    },

    playScanBeep: function () {
        try {
            const ctx = new (window.AudioContext || window.webkitAudioContext)();
            const osc = ctx.createOscillator();
            const gain = ctx.createGain();
            osc.type = 'sine';
            osc.frequency.setValueAtTime(880, ctx.currentTime);
            gain.gain.setValueAtTime(0.15, ctx.currentTime);
            gain.gain.exponentialRampToValueAtTime(0.01, ctx.currentTime + 0.12);
            osc.connect(gain);
            gain.connect(ctx.destination);
            osc.start();
            osc.stop(ctx.currentTime + 0.12);
        } catch (e) {}
    },

    downloadFile: function (filename, content, mimeType) {
        const blob = new Blob([content], { type: mimeType });
        const url = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = filename;
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        URL.revokeObjectURL(url);
    },

    downloadDataUrl: function (filename, dataUrl) {
        const a = document.createElement('a');
        a.href = dataUrl;
        a.download = filename;
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
    }
};

window.blazorSignaturePad = {
    instances: new Map(),

    init: function (canvasEl, dotNetHelper, options) {
        if (!canvasEl) return;

        options = Object.assign({
            penColor: '#0f172a',
            strokeWidth: 2.5,
            backgroundColor: 'transparent',
            guideLine: true
        }, options || {});

        const ctx = canvasEl.getContext('2d');
        let isDrawing = false;
        let strokes = [];
        let undoneStrokes = [];
        let currentStroke = null;

        function resize() {
            const rect = canvasEl.getBoundingClientRect();
            if (rect.width === 0 || rect.height === 0) return;
            const dpr = window.devicePixelRatio || 1;
            canvasEl.width = rect.width * dpr;
            canvasEl.height = rect.height * dpr;
            ctx.scale(dpr, dpr);
            redraw();
        }

        function getPos(e) {
            const rect = canvasEl.getBoundingClientRect();
            return {
                x: e.clientX - rect.left,
                y: e.clientY - rect.top
            };
        }

        function redraw() {
            const rect = canvasEl.getBoundingClientRect();
            ctx.clearRect(0, 0, rect.width, rect.height);

            for (const s of strokes) {
                drawStroke(s);
            }
            if (currentStroke) {
                drawStroke(currentStroke);
            }
        }

        function drawStroke(s) {
            if (!s.points || s.points.length === 0) return;
            ctx.save();
            ctx.strokeStyle = s.color;
            ctx.lineWidth = s.width;
            ctx.lineCap = 'round';
            ctx.lineJoin = 'round';

            if (s.points.length === 1) {
                ctx.fillStyle = s.color;
                ctx.beginPath();
                ctx.arc(s.points[0].x, s.points[0].y, s.width / 2, 0, Math.PI * 2);
                ctx.fill();
            } else {
                ctx.beginPath();
                ctx.moveTo(s.points[0].x, s.points[0].y);
                for (let i = 1; i < s.points.length - 1; i++) {
                    const midX = (s.points[i].x + s.points[i + 1].x) / 2;
                    const midY = (s.points[i].y + s.points[i + 1].y) / 2;
                    ctx.quadraticCurveTo(s.points[i].x, s.points[i].y, midX, midY);
                }
                const last = s.points[s.points.length - 1];
                ctx.lineTo(last.x, last.y);
                ctx.stroke();
            }
            ctx.restore();
        }

        function startDrawing(e) {
            e.preventDefault();
            isDrawing = true;
            try { canvasEl.setPointerCapture(e.pointerId); } catch(err){}
            const pos = getPos(e);
            currentStroke = {
                points: [pos],
                color: options.penColor,
                width: options.strokeWidth
            };
            undoneStrokes = [];
            redraw();
            notifyChange();
        }

        function draw(e) {
            if (!isDrawing || !currentStroke) return;
            e.preventDefault();
            const pos = getPos(e);
            currentStroke.points.push(pos);
            redraw();
        }

        function stopDrawing(e) {
            if (!isDrawing) return;
            e.preventDefault();
            isDrawing = false;
            try { canvasEl.releasePointerCapture(e.pointerId); } catch(err){}
            if (currentStroke && currentStroke.points.length > 0) {
                strokes.push(currentStroke);
                currentStroke = null;
                redraw();
                notifyChange();
            }
        }

        function notifyChange() {
            if (dotNetHelper) {
                dotNetHelper.invokeMethodAsync('OnSignatureChanged', {
                    isEmpty: strokes.length === 0,
                    strokeCount: strokes.length
                }).catch(() => {});
            }
        }

        canvasEl.addEventListener('pointerdown', startDrawing);
        canvasEl.addEventListener('pointermove', draw);
        canvasEl.addEventListener('pointerup', stopDrawing);
        canvasEl.addEventListener('pointercancel', stopDrawing);

        const resizeObserver = new ResizeObserver(() => resize());
        resizeObserver.observe(canvasEl);

        setTimeout(() => resize(), 50);

        const instance = {
            canvas: canvasEl,
            setPenColor: (c) => { options.penColor = c; },
            setStrokeWidth: (w) => { options.strokeWidth = w; },
            clear: () => {
                strokes = [];
                undoneStrokes = [];
                currentStroke = null;
                redraw();
                notifyChange();
            },
            undo: () => {
                if (strokes.length > 0) {
                    undoneStrokes.push(strokes.pop());
                    redraw();
                    notifyChange();
                }
            },
            redo: () => {
                if (undoneStrokes.length > 0) {
                    strokes.push(undoneStrokes.pop());
                    redraw();
                    notifyChange();
                }
            },
            isEmpty: () => strokes.length === 0,
            toDataURL: (mimeType = 'image/png', bgColor = 'transparent') => {
                const rect = canvasEl.getBoundingClientRect();
                const dpr = window.devicePixelRatio || 1;
                const exportCanvas = document.createElement('canvas');
                exportCanvas.width = rect.width * dpr;
                exportCanvas.height = rect.height * dpr;
                const expCtx = exportCanvas.getContext('2d');
                expCtx.scale(dpr, dpr);

                if (bgColor && bgColor !== 'transparent') {
                    expCtx.fillStyle = bgColor;
                    expCtx.fillRect(0, 0, rect.width, rect.height);
                }

                for (const s of strokes) {
                    if (!s.points || s.points.length === 0) continue;
                    expCtx.save();
                    expCtx.strokeStyle = s.color;
                    expCtx.lineWidth = s.width;
                    expCtx.lineCap = 'round';
                    expCtx.lineJoin = 'round';

                    if (s.points.length === 1) {
                        expCtx.fillStyle = s.color;
                        expCtx.beginPath();
                        expCtx.arc(s.points[0].x, s.points[0].y, s.width / 2, 0, Math.PI * 2);
                        expCtx.fill();
                    } else {
                        expCtx.beginPath();
                        expCtx.moveTo(s.points[0].x, s.points[0].y);
                        for (let i = 1; i < s.points.length - 1; i++) {
                            const midX = (s.points[i].x + s.points[i + 1].x) / 2;
                            const midY = (s.points[i].y + s.points[i + 1].y) / 2;
                            expCtx.quadraticCurveTo(s.points[i].x, s.points[i].y, midX, midY);
                        }
                        const last = s.points[s.points.length - 1];
                        expCtx.lineTo(last.x, last.y);
                        expCtx.stroke();
                    }
                    expCtx.restore();
                }
                return exportCanvas.toDataURL(mimeType);
            },
            toSvg: () => {
                const rect = canvasEl.getBoundingClientRect();
                let pathStr = '';
                for (const s of strokes) {
                    if (s.points.length < 2) continue;
                    let d = `M ${s.points[0].x.toFixed(1)} ${s.points[0].y.toFixed(1)}`;
                    for (let i = 1; i < s.points.length; i++) {
                        d += ` L ${s.points[i].x.toFixed(1)} ${s.points[i].y.toFixed(1)}`;
                    }
                    pathStr += `<path d="${d}" fill="none" stroke="${s.color}" stroke-width="${s.width}" stroke-linecap="round" stroke-linejoin="round"/>`;
                }
                return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 ${rect.width} ${rect.height}" width="${rect.width}" height="${rect.height}">${pathStr}</svg>`;
            },
            dispose: () => {
                resizeObserver.disconnect();
                canvasEl.removeEventListener('pointerdown', startDrawing);
                canvasEl.removeEventListener('pointermove', draw);
                canvasEl.removeEventListener('pointerup', stopDrawing);
                canvasEl.removeEventListener('pointercancel', stopDrawing);
                window.blazorSignaturePad.instances.delete(canvasEl);
            }
        };

        window.blazorSignaturePad.instances.set(canvasEl, instance);
    },

    setPenColor: function (canvasEl, color) {
        const inst = this.instances.get(canvasEl);
        if (inst) inst.setPenColor(color);
    },

    setStrokeWidth: function (canvasEl, width) {
        const inst = this.instances.get(canvasEl);
        if (inst) inst.setStrokeWidth(width);
    },

    clear: function (canvasEl) {
        const inst = this.instances.get(canvasEl);
        if (inst) inst.clear();
    },

    undo: function (canvasEl) {
        const inst = this.instances.get(canvasEl);
        if (inst) inst.undo();
    },

    redo: function (canvasEl) {
        const inst = this.instances.get(canvasEl);
        if (inst) inst.redo();
    },

    getDataURL: function (canvasEl, mimeType, bgColor) {
        const inst = this.instances.get(canvasEl);
        return inst ? inst.toDataURL(mimeType, bgColor) : null;
    },

    getSvg: function (canvasEl) {
        const inst = this.instances.get(canvasEl);
        return inst ? inst.toSvg() : null;
    },

    download: function (canvasEl, filename, mimeType, bgColor) {
        const inst = this.instances.get(canvasEl);
        if (!inst) return;
        const dataUrl = inst.toDataURL(mimeType, bgColor);
        window.blazorBarcodeScanner.downloadDataUrl(filename, dataUrl);
    },

    dispose: function (canvasEl) {
        const inst = this.instances.get(canvasEl);
        if (inst) inst.dispose();
    }
};

/* ==========================================================================
   Interactive Image Comparison Slider
   ========================================================================== */
window.blazorImageCompare = {
    instances: new Map(),

    init: function (containerEl, dotNetHelper, initialPos) {
        if (!containerEl) return;

        let isDragging = false;
        let position = initialPos !== undefined ? initialPos : 50;

        const updatePosition = (clientX) => {
            const rect = containerEl.getBoundingClientRect();
            if (rect.width <= 0) return;
            const x = Math.max(0, Math.min(clientX - rect.left, rect.width));
            const pct = Math.round((x / rect.width) * 1000) / 10; // 0.0 - 100.0%
            position = pct;
            containerEl.style.setProperty('--compare-pos', `${pct}%`);
            if (dotNetHelper) {
                dotNetHelper.invokeMethodAsync('OnPositionChanged', pct);
            }
        };

        const onPointerDown = (e) => {
            isDragging = true;
            containerEl.setPointerCapture(e.pointerId);
            updatePosition(e.clientX);
        };

        const onPointerMove = (e) => {
            if (!isDragging) return;
            updatePosition(e.clientX);
        };

        const onPointerUp = (e) => {
            if (isDragging) {
                isDragging = false;
                try { containerEl.releasePointerCapture(e.pointerId); } catch (_) { }
            }
        };

        containerEl.style.setProperty('--compare-pos', `${position}%`);
        containerEl.addEventListener('pointerdown', onPointerDown);
        containerEl.addEventListener('pointermove', onPointerMove);
        containerEl.addEventListener('pointerup', onPointerUp);
        containerEl.addEventListener('pointercancel', onPointerUp);

        this.instances.set(containerEl, {
            dispose: () => {
                containerEl.removeEventListener('pointerdown', onPointerDown);
                containerEl.removeEventListener('pointermove', onPointerMove);
                containerEl.removeEventListener('pointerup', onPointerUp);
                containerEl.removeEventListener('pointercancel', onPointerUp);
                window.blazorImageCompare.instances.delete(containerEl);
            }
        });
    },

    setPosition: function (containerEl, pct) {
        if (!containerEl) return;
        const clamped = Math.max(0, Math.min(pct, 100));
        containerEl.style.setProperty('--compare-pos', `${clamped}%`);
    },

    dispose: function (containerEl) {
        const inst = this.instances.get(containerEl);
        if (inst) inst.dispose();
    }
};

/* ==========================================================================
   Celebration Confetti Burst (Canvas Physics)
   ========================================================================== */
window.blazorConfetti = {
    fire: function (canvasEl, opts) {
        if (!canvasEl) return;
        const ctx = canvasEl.getContext('2d');
        if (!ctx) return;

        opts = opts || {};
        const count = opts.count || 80;
        const originX = opts.x !== undefined ? opts.x : 0.5;
        const originY = opts.y !== undefined ? opts.y : 0.5;
        const colors = opts.colors || [
            '#6366f1', '#4f46e5', '#10b981', '#f59e0b',
            '#ef4444', '#ec4899', '#8b5cf6', '#06b6d4'
        ];

        // Resize canvas to match display size
        const rect = canvasEl.getBoundingClientRect();
        canvasEl.width = rect.width * (window.devicePixelRatio || 1);
        canvasEl.height = rect.height * (window.devicePixelRatio || 1);
        ctx.scale(window.devicePixelRatio || 1, window.devicePixelRatio || 1);

        const startX = rect.width * originX;
        const startY = rect.height * originY;

        const particles = [];
        for (let i = 0; i < count; i++) {
            const angle = (Math.PI * 2 * (i / count)) + ((Math.random() - 0.5) * 0.8);
            const speed = 4 + Math.random() * 8;
            particles.push({
                x: startX,
                y: startY,
                vx: Math.cos(angle) * speed * (0.8 + Math.random() * 0.6),
                vy: Math.sin(angle) * speed * 1.2 - 3,
                color: colors[Math.floor(Math.random() * colors.length)],
                size: 5 + Math.random() * 6,
                rotation: Math.random() * 360,
                rotationSpeed: (Math.random() - 0.5) * 12,
                opacity: 1,
                decay: 0.012 + Math.random() * 0.016,
                shape: Math.random() > 0.4 ? 'rect' : 'circle'
            });
        }

        let animationFrameId;
        const animate = () => {
            ctx.clearRect(0, 0, rect.width, rect.height);
            let active = false;

            for (let i = 0; i < particles.length; i++) {
                const p = particles[i];
                if (p.opacity <= 0) continue;
                active = true;

                p.x += p.vx;
                p.y += p.vy;
                p.vy += 0.22; // gravity
                p.vx *= 0.98; // air resistance
                p.rotation += p.rotationSpeed;
                p.opacity -= p.decay;

                ctx.save();
                ctx.globalAlpha = Math.max(0, p.opacity);
                ctx.translate(p.x, p.y);
                ctx.rotate((p.rotation * Math.PI) / 180);
                ctx.fillStyle = p.color;

                if (p.shape === 'rect') {
                    ctx.fillRect(-p.size / 2, -p.size / 4, p.size, p.size / 2);
                } else {
                    ctx.beginPath();
                    ctx.arc(0, 0, p.size / 3, 0, Math.PI * 2);
                    ctx.fill();
                }
                ctx.restore();
            }

            if (active) {
                animationFrameId = requestAnimationFrame(animate);
            } else {
                ctx.clearRect(0, 0, rect.width, rect.height);
                cancelAnimationFrame(animationFrameId);
            }
        };

        animate();
    }
};

/* ==========================================================================
   Clipboard Helper
   ========================================================================== */
window.blazorClipboard = {
    copyText: async function (text) {
        if (!text) return false;
        try {
            if (navigator.clipboard && navigator.clipboard.writeText) {
                await navigator.clipboard.writeText(text);
                return true;
            }
        } catch (_) { }

        try {
            const textArea = document.createElement("textarea");
            textArea.value = text;
            textArea.style.position = "fixed";
            textArea.style.left = "-999999px";
            textArea.style.top = "-999999px";
            document.body.appendChild(textArea);
            textArea.focus();
            textArea.select();
            const successful = document.execCommand('copy');
            document.body.removeChild(textArea);
            return successful;
        } catch (_) {
            return false;
        }
    }
};






