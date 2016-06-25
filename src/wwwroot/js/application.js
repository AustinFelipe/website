(function(window) {

    'use strict';

    var tagSelector = 'data-tag';

    function init() {
        document.querySelectorAll('[' + tagSelector + ']').forEach(function(element) {
            element.addEventListener('click', onClickTag);
        }, this);
    }

    function onClickTag(evt) {
        evt.preventDefault();

        var selectorValue = evt.target.getAttribute(tagSelector);
        var searchElement = document.querySelector(selectorValue);
        var form;

        if (!searchElement)
            return;

        searchElement.value = evt.target.innerText;

        var el = searchElement;
        do {
            if (el.nodeName === 'FORM') {
                form = el;
                break;
            }
        } while (el = el.parentNode);

        if (!form)
            return;

        form.submit();
    }

    window.addEventListener('load', init);

})(window);