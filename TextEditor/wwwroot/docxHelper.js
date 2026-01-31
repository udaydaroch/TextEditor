window.generateAndDownloadDocx = async (htmlContent, filename) => {    
    try {
        const options = { margins: { top: 1440, right: 1440, bottom: 1440, left: 1440 } };

        const docxBlob = await window.docshift.toDocx(htmlContent, options);

        saveAs(docxBlob, filename);
        console.log("saveAs completed");

        return { success: true };

    } catch (error) {
        console.error("DOCX generation failed at some point:", error);
        return { success: false, error: error?.message || String(error) };
    }
};