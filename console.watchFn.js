console = console || {};

console.watchFn = function(obj, fn) {
    var $__obj__$ = Object.assign({}, obj);
    var $__fn__$ = $__obj__$[fn];

    obj[fn] = function() {
        debugger;
        $__fn__$.apply($__obj__$, arguments);
    }
}
