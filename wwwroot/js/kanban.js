/**
 * BlazorTailwindUI - Mobile-First Kanban Drag & Drop Engine
 * Universal touch & mouse drag support for Desktop, iOS Safari, and Android Chrome.
 */
window.BlazorKanban = {
    instances: new Map(),

    init: function (boardElement, dotNetHelper) {
        if (!boardElement) return;

        const boardId = boardElement.id || ('kanban-' + Math.random().toString(36).substring(2, 9));
        boardElement.id = boardId;

        let activeGhost = null;
        let draggedCard = null;
        let draggedCardId = null;
        let currentTargetColId = null;
        let touchStartX = 0;
        let touchStartY = 0;
        let cardRect = null;
        let offsetX = 0;
        let offsetY = 0;

        // --- DESKTOP HTML5 DRAG & DROP ---
        function onDragStart(e) {
            const card = e.target.closest('.btui-kanban-card');
            if (!card) return;

            draggedCard = card;
            draggedCardId = card.getAttribute('data-card-id');
            const col = card.closest('[data-column-id]');
            const sourceColId = col ? col.getAttribute('data-column-id') : '';

            e.dataTransfer.setData('text/plain', JSON.stringify({ cardId: draggedCardId, sourceColId }));
            e.dataTransfer.effectAllowed = 'move';

            setTimeout(() => {
                if (card) card.classList.add('opacity-40', 'scale-95');
            }, 0);
        }

        function onDragEnd(e) {
            const card = e.target.closest('.btui-kanban-card');
            if (card) {
                card.classList.remove('opacity-40', 'scale-95');
            }
            clearAllColumnHighlights();
            draggedCard = null;
            draggedCardId = null;
        }

        function onDragOver(e) {
            e.preventDefault();
            e.dataTransfer.dropEffect = 'move';

            const col = e.target.closest('[data-column-id]');
            if (col) {
                clearAllColumnHighlights();
                col.classList.add('ring-2', 'ring-brand-500', 'bg-brand-50/40', 'dark:bg-brand-950/30');
            }
        }

        function onDrop(e) {
            e.preventDefault();
            const col = e.target.closest('[data-column-id]');
            if (!col) return;

            const targetColId = col.getAttribute('data-column-id');
            clearAllColumnHighlights();

            let cardId = draggedCardId;
            try {
                const data = JSON.parse(e.dataTransfer.getData('text/plain') || '{}');
                if (data.cardId) cardId = data.cardId;
            } catch (err) { }

            if (cardId && targetColId) {
                dotNetHelper.invokeMethodAsync('OnCardDroppedJs', cardId, targetColId);
            }
        }

        // --- MOBILE IOS & ANDROID TOUCH DRAG ---
        function onTouchStart(e) {
            // Only initiate touch drag from the dedicated handle (or card if handle touched)
            const handle = e.target.closest('.btui-kanban-handle');
            if (!handle) return;

            const card = handle.closest('.btui-kanban-card');
            if (!card) return;

            const touch = e.touches[0];
            touchStartX = touch.clientX;
            touchStartY = touch.clientY;
            cardRect = card.getBoundingClientRect();
            offsetX = touchStartX - cardRect.left;
            offsetY = touchStartY - cardRect.top;

            draggedCard = card;
            draggedCardId = card.getAttribute('data-card-id');

            // Haptic vibration feedback on pick-up (supported on Android and modern browsers)
            if (navigator.vibrate) {
                navigator.vibrate(15);
            }

            // Create floating ghost element
            activeGhost = card.cloneNode(true);
            activeGhost.classList.add('fixed', 'pointer-events-none', 'z-50', 'shadow-2xl', 'opacity-90', 'scale-105', 'rotate-2', 'ring-2', 'ring-brand-500');
            activeGhost.style.width = cardRect.width + 'px';
            activeGhost.style.left = (touch.clientX - offsetX) + 'px';
            activeGhost.style.top = (touch.clientY - offsetY) + 'px';
            activeGhost.style.margin = '0';
            activeGhost.style.transition = 'none';
            document.body.appendChild(activeGhost);

            card.classList.add('opacity-30', 'scale-95');
        }

        function onTouchMove(e) {
            if (!activeGhost || !draggedCard) return;

            // Prevent screen scrolling while dragging card on mobile
            e.preventDefault();

            const touch = e.touches[0];
            activeGhost.style.left = (touch.clientX - offsetX) + 'px';
            activeGhost.style.top = (touch.clientY - offsetY) + 'px';

            // Detect column underneath current finger position
            activeGhost.style.display = 'none';
            const elemUnderFinger = document.elementFromPoint(touch.clientX, touch.clientY);
            activeGhost.style.display = '';

            const colUnderFinger = elemUnderFinger ? elemUnderFinger.closest('[data-column-id]') : null;

            if (colUnderFinger) {
                const colId = colUnderFinger.getAttribute('data-column-id');
                if (currentTargetColId !== colId) {
                    clearAllColumnHighlights();
                    currentTargetColId = colId;
                    colUnderFinger.classList.add('ring-2', 'ring-brand-500', 'bg-brand-50/40', 'dark:bg-brand-950/30');

                    // Subtle haptic tick when crossing lane threshold
                    if (navigator.vibrate) {
                        navigator.vibrate(8);
                    }
                }
            } else {
                clearAllColumnHighlights();
                currentTargetColId = null;
            }
        }

        function onTouchEnd(e) {
            if (!activeGhost && !draggedCard) return;

            if (activeGhost) {
                activeGhost.remove();
                activeGhost = null;
            }

            if (draggedCard) {
                draggedCard.classList.remove('opacity-30', 'scale-95');
            }

            if (draggedCardId && currentTargetColId) {
                dotNetHelper.invokeMethodAsync('OnCardDroppedJs', draggedCardId, currentTargetColId);

                // Success haptic chime pattern on mobile
                if (navigator.vibrate) {
                    navigator.vibrate([20, 40, 20]);
                }
            }

            clearAllColumnHighlights();
            draggedCard = null;
            draggedCardId = null;
            currentTargetColId = null;
        }

        function onTouchCancel(e) {
            if (activeGhost) {
                activeGhost.remove();
                activeGhost = null;
            }
            if (draggedCard) {
                draggedCard.classList.remove('opacity-30', 'scale-95');
            }
            clearAllColumnHighlights();
            draggedCard = null;
            draggedCardId = null;
            currentTargetColId = null;
        }

        function clearAllColumnHighlights() {
            const cols = boardElement.querySelectorAll('[data-column-id]');
            cols.forEach(col => {
                col.classList.remove('ring-2', 'ring-brand-500', 'bg-brand-50/40', 'dark:bg-brand-950/30');
            });
        }

        // Attach listeners
        boardElement.addEventListener('dragstart', onDragStart);
        boardElement.addEventListener('dragend', onDragEnd);
        boardElement.addEventListener('dragover', onDragOver);
        boardElement.addEventListener('drop', onDrop);

        // Touch listeners with passive: false to allow e.preventDefault()
        boardElement.addEventListener('touchstart', onTouchStart, { passive: true });
        window.addEventListener('touchmove', onTouchMove, { passive: false });
        window.addEventListener('touchend', onTouchEnd, { passive: true });
        window.addEventListener('touchcancel', onTouchCancel, { passive: true });

        this.instances.set(boardId, {
            destroy: function () {
                boardElement.removeEventListener('dragstart', onDragStart);
                boardElement.removeEventListener('dragend', onDragEnd);
                boardElement.removeEventListener('dragover', onDragOver);
                boardElement.removeEventListener('drop', onDrop);

                boardElement.removeEventListener('touchstart', onTouchStart);
                window.removeEventListener('touchmove', onTouchMove);
                window.removeEventListener('touchend', onTouchEnd);
                window.removeEventListener('touchcancel', onTouchCancel);
            }
        });
    },

    destroy: function (boardElement) {
        if (!boardElement || !boardElement.id) return;
        const instance = this.instances.get(boardElement.id);
        if (instance) {
            instance.destroy();
            this.instances.delete(boardElement.id);
        }
    }
};
