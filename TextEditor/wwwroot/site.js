// wwwroot/js/site.js

window.printHtmlAsPdf = async (htmlContent, fileName) => {
    // Create a hidden iframe
    const iframe = document.createElement('iframe');
    iframe.style.display = 'none';
    document.body.appendChild(iframe);

    const iframeDoc = iframe.contentDocument || iframe.contentWindow.document;
    iframeDoc.open();
    iframeDoc.write(htmlContent);
    iframeDoc.close();

    // Wait for images/fonts to load (important!)
    await new Promise(resolve => {
        iframe.onload = () => {
            setTimeout(resolve, 500); // small delay for rendering
        };
        // In case onload doesn't fire
        setTimeout(resolve, 2000);
    });

    // Trigger print → browser shows "Save as PDF"
    iframe.contentWindow.focus();
    iframe.contentWindow.print();

    // Clean up
    setTimeout(() => {
        document.body.removeChild(iframe);
    }, 1000);
};