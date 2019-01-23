using System;
using System.Runtime.CompilerServices;

using Color = System.Windows.Media.Color;

using static UltimateOrb.Graphics.Serialization.Gltf.GltfModule;

namespace UltimateOrb.Graphics.Serialization.Gltf.Importers.WPF {

    public static class GltfModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Color ToColor(this float[] value) {
            if (null == value) {
                throw ThrowArgumentNullException_ToColor();
            }
            var c = value.Length;
            if (3 <= c) {
                if (c <= 4) {
                    var r = value[0];
                    CheckColorComponent(r);
                    var g = value[1];
                    CheckColorComponent(g);
                    var b = value[2];
                    CheckColorComponent(b);
                    float a;
                    if (c > 3) {
                        a = value[3];
                        CheckColorComponent(a);
                    } else {
                        a = (float)1.0;
                    }
                    return Color.FromArgb(ColorValueToByte(a), ColorValueToByte(r), ColorValueToByte(g), ColorValueToByte(b));
                }
            }
            throw ThrowInvalidCastException_ToColor();
        }

        private static InvalidCastException ThrowInvalidCastException_ToColor() {
            throw new InvalidCastException();
        }

        private static ArgumentNullException ThrowArgumentNullException_ToColor() {
            throw new ArgumentNullException();
        }
    }
}
