using System;

namespace CodeBase.Infrastructure.Observables
{
    /// <summary>
    /// Wraps a value in order to allow observing its value change
    /// </summary>
    /// <example>>
    ///   var obs = new Observable<int>(123);
    ///   obs.OnChanged += (o, oldVal, newVal) => Log("changed from " + oldVal + " to " + newVal);
    ///   obs.Value = 456; // dispatches OnChanged
    /// </example>
    /// <author>Jackson Dunstan, http://JacksonDunstan.com/articles/3547</author>
    /// <license>MIT</license>
    [Serializable]
    public class Observable<T> : IEquatable<Observable<T>>
    {
        private T _value;
 
        public Observable()
        {
        }
 
        public Observable(T value)
        {
            _value = value;
        }
 
        public Action<Observable<T>, T, T> OnChanged;
 
        public T Value
        {
            get { return _value; }
            set
            {
                var oldValue = _value;
                _value = value;
                if (OnChanged != null)
                {
                    OnChanged(this, oldValue, value);
                }
            }
        }
 
        public static implicit operator Observable<T>(T observable)
        {
            return new Observable<T>(observable);
        }
 
        public static explicit operator T(Observable<T> observable)
        {
            return observable._value;
        }
 
        public override string ToString()
        {
            return _value.ToString();
        }
 
        public bool Equals(Observable<T> other)
        {
            return other._value.Equals(_value);
        }
 
        public override bool Equals(object other)
        {
            return other != null
                   && other is Observable<T>
                   && ((Observable<T>)other)._value.Equals(_value);
        }
 
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}