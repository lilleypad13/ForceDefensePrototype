using UnityEngine;

namespace Helpers
{
    public static class PhysicsHelper
    {
        private const float COULOMBCONSTANT = 2.0f;
        private const float GRAVITATIONALCONSTANT = 4.0f;

        public static Vector3 CoulombForce(float chargeA, float chargeB, Vector3 displacementVector)
        {
            return displacementVector.normalized
                * COULOMBCONSTANT * chargeA * chargeB
                / (Vector3.Magnitude(displacementVector) * Vector3.Magnitude(displacementVector));
        }

        public static Vector3 GravitationalForce(float massA, float massB, Vector3 displacementVector)
        {
            return -displacementVector.normalized
            * GRAVITATIONALCONSTANT * massA * massB
                / (Vector3.Magnitude(displacementVector) * Vector3.Magnitude(displacementVector));
        }
    }
}

