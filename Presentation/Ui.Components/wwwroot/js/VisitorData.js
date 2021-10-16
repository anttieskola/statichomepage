// GetWindowNavigatorProperty
// https://html.spec.whatwg.org/multipage/system-state.html#dom-navigator
export function GetWindowNavigatorProperty(propertyName) {
    return window.navigator[propertyName];
}
