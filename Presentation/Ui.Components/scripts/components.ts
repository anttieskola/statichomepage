// GetWindowNavigatorProperty
// https://html.spec.whatwg.org/multipage/system-state.html#dom-navigator
function GetWindowNavigatorProperty(propertyName) {
    return window.navigator[propertyName];
}
