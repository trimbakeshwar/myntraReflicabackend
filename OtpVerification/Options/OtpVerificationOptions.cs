namespace MyntraBacked.Options
{
    public class OtpVerificationOptions
    {
        /// <summary>
        /// Enable or disable in-memory cache
        /// <para>Note: when enable in-memory will disable default cache (redis) </para>
        /// <para>default value: <see langword="false"/> (reids) will handle caching </para>
        /// </summary>
        internal bool IsInMemoryCache { get; set; } = false;

        /// <summary>
        /// Active to generate URL to verify code with Id OTP
        /// </summary>
        public bool EnableUrl { get; set; } = true;

        public int Iterations { get; set; } = 1;
        public int Size { get; set; } = 6;
        public int Length { get; set; } = 20;
        public int Expire { get; set; } = 2;
    }
}
