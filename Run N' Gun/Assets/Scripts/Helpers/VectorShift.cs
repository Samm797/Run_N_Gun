using UnityEngine;

public class VectorShift
{
    /// <summary>
    /// Shifts a Vector3 by X degree angles around the Z axis. Use true for left, false for right. 
    /// </summary>
    /// <param name="direction">Initial Vector you are shifting from.</param>
    /// <param name="isLeft">True for shifting left, false for shifting right.</param>
    /// <param name="degrees">The number of degrees (as a float) you would like the Vector to be shifted either left or right.</param>
    /// <returns>A new Vector 3 with an X deg shift from the initial Vector3 around the Z axis.</returns>
    public Vector3 ZShiftVectorXDegreesLeft(Vector3 direction, bool isLeft, float degrees)
    {
        if (isLeft)
        {
            return (Quaternion.Euler(0f, 0f, degrees) * direction).normalized;
        }
        else
        {
            return (Quaternion.Euler(0f, 0f, degrees) * direction).normalized;
        }
    }

    /// <summary>
    /// Shifts a Vector3 by X degree angles around the Z axis. Use true for left, false for right. 
    /// </summary>
    /// <param name="direction">Initial Vector you are shifting from.</param>
    /// <param name="isLeft">True for shifting left, false for shifting right.</param>
    /// <param name="degrees">The number of degrees (as a float) you would like the Vector to be shifted either left or right.</param>
    /// <returns>A new Vector 3 with an X deg shift from the initial Vector3 around the Z axis.</returns>
    public Vector3 ZShiftVectorXDegreesLeft(Vector2 direction, bool isLeft, float degrees)
    {
        return ZShiftVectorXDegreesLeft((Vector3)direction, isLeft, degrees);
    }

    /// <summary>
    /// Shifts a Vector3 by X degree angles around the Z axis. Use true for left, false for right. 
    /// </summary>
    /// <param name="x">X value you are shifting from.</param>
    /// <param name="y">Y value you are shifting from.</param>
    /// <param name="z">Z value you are shifting from.</param>
    /// <param name="isLeft">True for shifting left, false for shifting right.</param>
    /// <param name="degrees">The number of degrees (as a float) you would like the Vector to be shifted either left or right.</param>
    /// <returns>A new Vector 3 with an X deg shift from the initial Vector3 around the Z axis.</returns>
    public Vector3 ZShiftVectorXDegreesLeft(float x, float y, float z, bool isLeft, float degrees)
    {
        return ZShiftVectorXDegreesLeft((new Vector3(x, y, z)), isLeft, degrees);
    }
}
