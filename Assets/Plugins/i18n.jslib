mergeInto(LibraryManager.library, {
    t: function (key, count) {
        var keyStr = Pointer_stringify(key);
        var returnStr = i18n.t(keyStr, {count: count});

        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    language: function() {
        var returnStr = i18n.language;

        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    }
});