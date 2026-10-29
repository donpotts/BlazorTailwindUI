// PDF Helper: Client-side Download & Printing for Flattened Documents
window.pdfHelper = {
    downloadBlob: function (filename, mimeType, base64Data) {
        try {
            const byteCharacters = atob(base64Data);
            const byteNumbers = new Array(byteCharacters.length);
            for (let i = 0; i < byteCharacters.length; i++) {
                byteNumbers[i] = byteCharacters.charCodeAt(i);
            }
            const byteArray = new Uint8Array(byteNumbers);
            const blob = new Blob([byteArray], { type: mimeType });
            const url = URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = filename;
            document.body.appendChild(a);
            a.click();
            setTimeout(function () {
                if (document.body.contains(a)) {
                    document.body.removeChild(a);
                }
                URL.revokeObjectURL(url);
            }, 1000);
            return true;
        } catch (e) {
            console.error('Failed to download blob:', e);
            return false;
        }
    },
    printPdfBase64: function (base64Data) {
        try {
            const byteCharacters = atob(base64Data);
            const byteNumbers = new Array(byteCharacters.length);
            for (let i = 0; i < byteCharacters.length; i++) {
                byteNumbers[i] = byteCharacters.charCodeAt(i);
            }
            const byteArray = new Uint8Array(byteNumbers);
            const blob = new Blob([byteArray], { type: 'application/pdf' });
            const blobUrl = URL.createObjectURL(blob);

            let iframe = document.getElementById('__pdf_print_iframe__');
            if (!iframe) {
                iframe = document.createElement('iframe');
                iframe.id = '__pdf_print_iframe__';
                iframe.style.position = 'fixed';
                iframe.style.right = '0';
                iframe.style.bottom = '0';
                iframe.style.width = '0';
                iframe.style.height = '0';
                iframe.style.border = '0';
                document.body.appendChild(iframe);
            }

            iframe.onload = function () {
                setTimeout(function () {
                    try {
                        iframe.contentWindow.focus();
                        iframe.contentWindow.print();
                    } catch (e) {
                        console.warn('Iframe print restricted, opening PDF tab:', e);
                        window.open(blobUrl, '_blank');
                    }
                }, 300);
            };
            iframe.src = blobUrl;
            return true;
        } catch (e) {
            console.error('Failed to print PDF:', e);
            return false;
        }
    },
    downloadText: function (filename, mimeType, textContent) {
        try {
            const blob = new Blob([textContent], { type: mimeType });
            const url = URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = filename;
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            URL.revokeObjectURL(url);
            return true;
        } catch (e) {
            console.error('Failed to download text:', e);
            return false;
        }
    },
    printDocument: function () {
        window.print();
        return true;
    }
};
