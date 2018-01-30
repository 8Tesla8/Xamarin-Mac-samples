using System;
using System.Collections.Generic;
using Foundation;

namespace MacArchitecture.UiElements.Helpers {
    public abstract class BindingObject : NSObject {
        protected void SetField<T>(ref T field, T value, string propertyName, Action<T> callback = null) {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            WillChangeValue(propertyName);
            field = value;
            DidChangeValue(propertyName);

            callback?.Invoke(value);
        }
    }
}
