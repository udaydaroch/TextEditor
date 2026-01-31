window.quillEditor = null;

window.initQuill = function (elementId) {
    if (window.quillEditor) {
        return;
    }

    var toolbarOptions = [
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
        [{ 'font': [] }],
        [{ 'size': ['small', false, 'large', 'huge'] }],
        
        ['bold', 'italic', 'underline', 'strike'],
        [{ 'color': [] }, { 'background': [] }],
        
        [{ 'list': 'ordered'}, { 'list': 'bullet' }],
        [{ 'indent': '-1'}, { 'indent': '+1' }],
        [{ 'align': [] }],
        
        ['blockquote', 'code-block'],
        ['link', 'image', 'video'],
        
        ['clean']
    ];

    window.quillEditor = new Quill('#' + elementId, {
        modules: {
            toolbar: toolbarOptions
        },
        theme: 'snow',
        placeholder: 'Start writing your document...'
    });
};

window.getQuillContent = function () {
    if (window.quillEditor) {
        return window.quillEditor.root.innerHTML;
    }
    return '';
};

window.setQuillContent = function (html) {
    if (window.quillEditor) {
        window.quillEditor.root.innerHTML = html || '';
    }
};

window.destroyQuill = function () {
    if (window.quillEditor) {
        window.quillEditor = null;
    }
};