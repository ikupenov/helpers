console = console || {};

console.watchFn = function(obj, fn) {
    var $__obj__$ = obj;
    var $__fn__$ = fn;

    obj[fn] = function() {
        debugger;
        $__fn__$.apply($__obj__$, arguments);
    }
}
