using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UltimateOrb.Graphics.Serialization.Gltf {

    public static class GltfModule {

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static byte ColorValueToByte(float value) {
            return unchecked((byte)(255f * value));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static void CheckColorComponent(float value) {
            if (0 <= value && value <= 1) {
                return;
            }
            throw ThrowArgumentOutOfRangeException_CheckColorComponent();
        }

        private static ArgumentOutOfRangeException ThrowArgumentOutOfRangeException_CheckColorComponent() {
            throw new ArgumentOutOfRangeException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static int SizeOf<T>() where T : unmanaged {
            return Unsafe.SizeOf<T>();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TOutput ConvertNormalize<TInput, TOutput>(TInput value)
            where TInput : struct
            where TOutput : struct {
            if (typeof(SByte) == typeof(TInput)) {
                var t = (SByte)(object)value;
                if (typeof(Single) == typeof(TOutput)) {
                    if (SByte.MinValue != t) {
                        return (TOutput)(object)unchecked((Single)t / SByte.MaxValue);
                    }
                    return (TOutput)(object)unchecked((Single)(-1));
                } else if (typeof(Double) == typeof(TOutput)) {
                    if (SByte.MinValue != t) {
                        return (TOutput)(object)unchecked((Double)t / SByte.MaxValue);
                    }
                    return (TOutput)(object)unchecked((Double)(-1));
                }
            } else if (typeof(Byte) == typeof(TInput)) {
                var t = (Byte)(object)value;
                if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t / Byte.MaxValue);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t / Byte.MaxValue);
                }
            } else if (typeof(Int16) == typeof(TInput)) {
                var t = (Int16)(object)value;
                if (typeof(Single) == typeof(TOutput)) {
                    if (Int16.MinValue != t) {
                        return (TOutput)(object)unchecked((Single)t / Int16.MaxValue);
                    }
                    return (TOutput)(object)unchecked((Single)(-1));
                } else if (typeof(Double) == typeof(TOutput)) {
                    if (Int16.MinValue != t) {
                        return (TOutput)(object)unchecked((Double)t / Int16.MaxValue);
                    }
                    return (TOutput)(object)unchecked((Double)(-1));
                }
            } else if (typeof(UInt16) == typeof(TInput)) {
                var t = (UInt16)(object)value;
                if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t / UInt16.MaxValue);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t / UInt16.MaxValue);
                }
            } else if (typeof(UInt32) == typeof(TInput)) {
                var t = (UInt32)(object)value;
                if (typeof(Single) == typeof(TOutput)) {
                    if (t <= (UInt32)16777216) {
                        return (TOutput)(object)unchecked((Single)t / UInt32.MaxValue);
                    }
                    throw ThrowArithmeticException_Convert();
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t / UInt32.MaxValue);
                }
            } else if (typeof(Single) == typeof(TInput)) {
                var t = (Single)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    if (t <= (Single)16777216 && (Single)(-16777216) <= t) {
                        return (TOutput)(object)unchecked((Int32)t);
                    }
                    throw ThrowArithmeticException_Convert();
                } else if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            }
            {
                throw ThrowNotSupportedException_Convert();
            }
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static TOutput Convert<TInput, TOutput>(TInput value)
            where TInput : struct
            where TOutput : struct {
            if (typeof(SByte) == typeof(TInput)) {
                var t = (SByte)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Int32)t);
                } else if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            } else if (typeof(Byte) == typeof(TInput)) {
                var t = (Byte)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Int32)t);
                } else if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            } else if (typeof(Int16) == typeof(TInput)) {
                var t = (Int16)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Int32)t);
                } else if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            } else if (typeof(UInt16) == typeof(TInput)) {
                var t = (UInt16)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Int32)t);
                } else if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            } else if (typeof(UInt32) == typeof(TInput)) {
                var t = (UInt32)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    return (TOutput)(object)checked((Int32)t);
                } else if (typeof(Single) == typeof(TOutput)) {
                    if (t <= (UInt32)16777216) {
                        return (TOutput)(object)unchecked((Single)t);
                    }
                    throw ThrowArithmeticException_Convert();
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            } else if (typeof(Single) == typeof(TInput)) {
                var t = (Single)(object)value;
                if (typeof(Int32) == typeof(TOutput)) {
                    if (t <= (Single)16777216 && (Single)(-16777216) <= t) {
                        return (TOutput)(object)unchecked((Int32)t);
                    }
                    throw ThrowArithmeticException_Convert();
                } else if (typeof(Single) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Single)t);
                } else if (typeof(Double) == typeof(TOutput)) {
                    return (TOutput)(object)unchecked((Double)t);
                }
            }
            {
                throw ThrowNotSupportedException_Convert();
            }
        }

        private static NotSupportedException ThrowNotSupportedException_Convert() {
            throw new NotSupportedException();
        }

        private static ArithmeticException ThrowArithmeticException_Convert() {
            throw new ArithmeticException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(this IReadOnlyList<byte> list, int index) where T : struct {
            if (typeof(SByte) == typeof(T)) {
                return (T)(object)list.ReadSByte(index);
            } else if (typeof(Byte) == typeof(T)) {
                return (T)(object)list.ReadByte(index);
            } else if (typeof(Int16) == typeof(T)) {
                return (T)(object)list.ReadInt16(index);
            } else if (typeof(UInt16) == typeof(T)) {
                return (T)(object)list.ReadUInt16(index);
            } else if (typeof(UInt32) == typeof(T)) {
                return (T)(object)list.ReadUInt32(index);
            } else if (typeof(Single) == typeof(T)) {
                return (T)(object)list.ReadSingle(index);
            }
            {
                throw ThrowNotSupportedException_Convert();
            }
        }

        private static NotSupportedException ThrowNotSupportedException_Read() {
            throw new NotSupportedException();
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static SByte ReadSByte(this IReadOnlyList<byte> list, int index) {
            return unchecked((SByte)list[index]);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Byte ReadByte(this IReadOnlyList<byte> list, int index) {
            return unchecked((Byte)list[index]);
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16(this IReadOnlyList<byte> list, int index) {
            return unchecked((Int16)((list[1 + index] << 8) | list[index]));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16(this IReadOnlyList<byte> list, int index) {
            return unchecked((UInt16)((list[1 + index] << 8) | list[index]));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32(this IReadOnlyList<byte> list, int index) {
            return unchecked((UInt32)((list[3 + index] << 24) | (list[2 + index] << 16) | (list[1 + index] << 8) | list[index]));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Single ReadSingle(this IReadOnlyList<byte> list, int index) {
            return unchecked(Int32BitsToSingle((list[3 + index] << 24) | (list[2 + index] << 16) | (list[1 + index] << 8) | list[index]));
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        public static Single Int32BitsToSingle(Int32 value) {
            Span<Int32> buffer = stackalloc Int32[1] {
                value,
            };
            return System.Runtime.InteropServices.MemoryMarshal.Cast<Int32, Single>(buffer)[0];
        }

        public static T HandleBy<T>(this T value, Action<T> action) where T : class {
            action(value);
            return value;
        }
    }
}
