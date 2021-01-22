mergeInto(LibraryManager.library, {
    getInitScene: function () {
        if (typeof window !== 'undefined' &&
        window.currentScene) {
            var bufferSize = lengthBytesUTF8(window.currentScene) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(window.currentScene, buffer, bufferSize);
            return buffer;
    
        }

        return null;
    },
    allowGoHome: function() {
        if (typeof window === 'undefined' || window.hideGoHome) {
            return false;
        }

        return true;
    },
    getBaseUrl: function() {
        var baseUrl = "http://localhost:3000/games/find-differences";
        if(typeof window !== 'undefined' && window.location) {
            baseUrl = window.location.origin + "/games/find-differences";
        }

        var bufferSize = lengthBytesUTF8(baseUrl) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(baseUrl, buffer, bufferSize);
        return buffer;
    },
});