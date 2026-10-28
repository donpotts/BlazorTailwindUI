// BlazorTailwindUI - Genuine Tesseract.js WebAssembly OCR Engine Bridge
// Connects Blazor WASM with https://github.com/tesseract-ocr/tesseract (via Tesseract.js WASM port)

window.TesseractOcrBridge = {
    _worker: null,
    _isInitializing: false,
    _isReady: false,

    isReady: function () {
        return this._isReady || (typeof Tesseract !== 'undefined');
    },

    init: async function () {
        if (this._isReady) return true;
        if (typeof Tesseract === 'undefined') {
            console.warn('[Tesseract] Tesseract library not yet loaded');
            return false;
        }
        try {
            this._isReady = true;
            console.log('[Tesseract] Tesseract WebAssembly engine ready');
            return true;
        } catch (err) {
            console.error('[Tesseract] Init error:', err);
            return false;
        }
    },

    recognizeImage: async function (imageSource, progressDotNetHelper) {
        const startTime = performance.now();

        if (typeof Tesseract === 'undefined') {
            return {
                success: false,
                errorMessage: "Tesseract engine not loaded.",
                text: "",
                words: [],
                confidence: 0,
                durationMs: 0
            };
        }

        try {
            const worker = await Tesseract.createWorker('eng', 1, {
                logger: m => {
                    if (progressDotNetHelper && m.status === 'recognizing text') {
                        try {
                            const pct = Math.round((m.progress || 0) * 100);
                            progressDotNetHelper.invokeMethodAsync('OnTesseractProgress', pct, m.status);
                        } catch (e) { }
                    }
                }
            });

            const result = await worker.recognize(imageSource);
            await worker.terminate();

            const durationMs = Math.round(performance.now() - startTime);
            const data = result.data;

            // Extract words and bounding boxes
            const words = (data.words || []).map(w => ({
                text: w.text,
                confidence: w.confidence,
                bbox: {
                    x0: w.bbox.x0,
                    y0: w.bbox.y0,
                    x1: w.bbox.x1,
                    y1: w.bbox.y1
                }
            }));

            // Extract lines
            const lines = (data.lines || []).map(l => ({
                text: l.text,
                confidence: l.confidence
            }));

            return {
                success: true,
                text: data.text,
                lines: lines,
                words: words,
                confidence: data.confidence,
                durationMs: durationMs
            };
        } catch (err) {
            console.error('[Tesseract] Recognition failed:', err);
            return {
                success: false,
                errorMessage: err.message || err.toString(),
                text: "",
                words: [],
                confidence: 0,
                durationMs: Math.round(performance.now() - startTime)
            };
        }
    },

    renderCheckToDataUrl: function (payer, checkNum, date, payee, amount, words, memo, bankName, micrLine) {
        try {
            const canvas = document.createElement('canvas');
            canvas.width = 1200;
            canvas.height = 540;
            const ctx = canvas.getContext('2d');

            // Background
            ctx.fillStyle = '#ffffff';
            ctx.fillRect(0, 0, canvas.width, canvas.height);

            // Subtle border
            ctx.strokeStyle = '#334155';
            ctx.lineWidth = 3;
            ctx.strokeRect(10, 10, canvas.width - 20, canvas.height - 20);

            // Security pattern background lines
            ctx.strokeStyle = '#f1f5f9';
            ctx.lineWidth = 1;
            for (let y = 30; y < canvas.height - 30; y += 15) {
                ctx.beginPath();
                ctx.moveTo(20, y);
                ctx.lineTo(canvas.width - 20, y);
                ctx.stroke();
            }

            // Payer Info
            ctx.fillStyle = '#0f172a';
            ctx.font = 'bold 22px Arial, sans-serif';
            ctx.fillText(payer || 'ACME ENTERPRISE CORP', 40, 55);
            ctx.font = '14px Arial, sans-serif';
            ctx.fillStyle = '#475569';
            ctx.fillText('100 Silicon Way, Tech City, CA 94016', 40, 80);

            // Check Number & Date
            ctx.fillStyle = '#0f172a';
            ctx.font = 'bold 24px monospace';
            ctx.fillText('CHECK #' + (checkNum || '1001'), 980, 55);
            ctx.font = '16px Arial, sans-serif';
            ctx.fillText('DATE: ' + (date || new Date().toLocaleDateString()), 920, 95);

            // Pay to the Order of
            ctx.font = 'bold 15px Arial, sans-serif';
            ctx.fillStyle = '#334155';
            ctx.fillText('PAY TO THE ORDER OF:', 40, 170);

            ctx.font = 'bold italic 24px "Times New Roman", serif';
            ctx.fillStyle = '#0f172a';
            ctx.fillText(payee || 'Jane Doe Consulting', 240, 170);

            // Courtesy Box
            ctx.strokeStyle = '#0f172a';
            ctx.lineWidth = 2;
            ctx.strokeRect(960, 140, 200, 45);
            ctx.fillStyle = '#f8fafc';
            ctx.fillRect(961, 141, 198, 43);
            ctx.fillStyle = '#0f172a';
            ctx.font = 'bold 24px monospace';
            ctx.fillText('$' + amount, 980, 172);

            // Legal words
            ctx.font = 'italic 18px "Times New Roman", serif';
            ctx.fillStyle = '#0f172a';
            ctx.fillText(words || 'Five thousand and 00/100 Dollars', 40, 240);
            ctx.font = 'bold 14px Arial, sans-serif';
            ctx.fillText('DOLLARS', 1080, 240);

            // Bank Name
            ctx.font = 'bold 16px Arial, sans-serif';
            ctx.fillStyle = '#334155';
            ctx.fillText(bankName || 'JPMorgan Chase Bank, N.A.', 40, 310);

            // Memo
            ctx.font = '14px Arial, sans-serif';
            ctx.fillText('MEMO: ' + (memo || 'Consulting Services'), 40, 390);

            // Signature line
            ctx.strokeStyle = '#475569';
            ctx.beginPath();
            ctx.moveTo(850, 390);
            ctx.lineTo(1150, 390);
            ctx.stroke();
            ctx.font = 'italic 28px "Brush Script MT", cursive, serif';
            ctx.fillStyle = '#1e3a8a';
            ctx.fillText('Authorized Signature', 880, 380);

            // MICR Band
            ctx.fillStyle = '#f8fafc';
            ctx.fillRect(20, 440, canvas.width - 40, 75);
            ctx.strokeStyle = '#cbd5e1';
            ctx.lineWidth = 1;
            ctx.strokeRect(20, 440, canvas.width - 40, 75);

            ctx.font = 'bold 28px monospace';
            ctx.fillStyle = '#0f172a';
            ctx.fillText(micrLine || 'A121000358A 0123456789C 1001', 120, 490);

            return canvas.toDataURL('image/png');
        } catch (e) {
            console.error('Canvas error:', e);
            return null;
        }
    }
};
