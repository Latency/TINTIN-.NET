using System;
using System.Collections.Specialized;
using System.Reflection;
using BitFields;


namespace TinTin {
  public static class BitVector<T> where T : struct {
// ReSharper disable once StaticFieldInGenericType
    private static readonly BitVector32 _bitv = new BitVector32(0);

    static BitVector() {
      if (!typeof(T).IsEnum)
        throw new ArgumentException($"T must be of type {typeof (T).FullName}");
      	// Initialize masks.
      var masks = new int[32];  // Holds 32 masks
      masks[0] = BitVector32.CreateMask();
      for (var i = 1; i < 32; i++)
	    masks[i] = BitVector32.CreateMask(masks[i - 1]);

      // Map
      foreach (Enum enm in EnumExtensions.GetAllItems<T>()) {
        enm.HasFlag()
      }
    }

    public void Toggle(T bit) {
      if (!Contains(bit))
        throw ArgumentException(MethodBase.GetCurrentMethod().DeclaringType.Name);

      ) _bitv[bit] = !_bitv[bit]; }
    public void Remove(T bit) { _bitv[bit] = false; }
    public void Set(T bit) { _bitv[bit] = true; }

    public bool this[T bit] {
      get { return _bitv[bit]; }
      set { _bitv[bit] = value; }
    }

    public bool IsEqual(object obj) {
      return _bitv.Equals(obj);
    }
  }
}