using System;
using Vector3D = OpenTK.Vector3d;

namespace UltimateOrb.Graphics.Materials {

    public struct MetallicRoughnessFactor {
        public Vector3D BaseColor;
        public double Opacity;
        public double Metallic;
        public double Roughness;
    }

    public struct SpecularGlossinessFactor {
        public Vector3D Diffuse;
        public double Opacity;
        public Vector3D Specular;
        public double Glossiness;
    }


    public static class MaterialConvert {
        private const double dielectricSpecular = 0.04;
        private const double epsilon = 1e-6;

        private static double GetMetallic(double diffuse, double specular, double oneMinusSpecularStrength) {
            if (specular < dielectricSpecular) {
                return 0;
            }
            var a = dielectricSpecular;
            var b = diffuse * oneMinusSpecularStrength / (1 - dielectricSpecular) + specular - 2 * dielectricSpecular;
            var c = dielectricSpecular - specular;
            var D = b * b - 4 * a * c;
            return Math.Max(0, Math.Min(1, (-b + Math.Sqrt(D)) / (2 * a)));
        }
        private static double GetMaxComponent(this Vector3D color) {
            return Math.Max(color.X, Math.Max(color.Y, color.Z));
        }

        private static double GetPerceivedBrightness(this Vector3D color) {
            return Math.Sqrt(0.299 * color.X * color.X + 0.587 * color.Y * color.Y + 0.114 * color.Z * color.Z);
        }

        private static Vector3D Clamp(Vector3D color) {
            return new Vector3D(Clamp(color.X), Clamp(color.Y), Clamp(color.Z));
        }

        private static double Clamp(double value) {
            return Math.Max(0, Math.Min(1, value));
        }

        private static Vector3D Lerp(Vector3D v0, Vector3D v1, double t) {
            return (1 - t) * v0 + t * v1;
        }

        public static MetallicRoughnessFactor ToMetallicRoughness(this SpecularGlossinessFactor specularGlossiness) {
            var oneMinusSpecularStrength = 1 - specularGlossiness.Specular.GetMaxComponent();
            var metallic = GetMetallic(specularGlossiness.Diffuse.GetPerceivedBrightness(), specularGlossiness.Specular.GetPerceivedBrightness(), oneMinusSpecularStrength);

            var baseColorFromDiffuse = (oneMinusSpecularStrength / (1 - dielectricSpecular) / Math.Max(1 - metallic, epsilon)) * specularGlossiness.Diffuse;
            var baseColorFromSpecular = (1 / Math.Max(metallic, epsilon)) * (specularGlossiness.Specular - (1 - metallic) * new Vector3D(dielectricSpecular, dielectricSpecular, dielectricSpecular));
            var baseColor = Clamp(Lerp(baseColorFromDiffuse, baseColorFromSpecular, metallic * metallic));
            return new MetallicRoughnessFactor() {
                BaseColor = baseColor,
                Opacity = specularGlossiness.Opacity,
                Metallic = metallic,
                Roughness = 1 - specularGlossiness.Glossiness,
            };
        }
    }
}
