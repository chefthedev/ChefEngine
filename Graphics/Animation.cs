using System;
using System.Collections.Generic;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// Animation class to represent movement with texture regions.
    /// </summary>
    public class Animation
    {
        // The list of texture regions to sequence through in the animation.
        public List<TextureRegion> AnimationFrames { get; set; }

        // The delay between each animation frame in the sequence, in milliseconds
        public TimeSpan DelayMs { get; set; }

        /// <summary>
        /// Constructor for the animation class.
        /// </summary>
        /// <param name="animationFrames">The list of texture regions representing each animation frame.</param>
        /// <param name="delayMs">The delay between showing each animation frame, in milliseconds.</param>
        public Animation(List<TextureRegion> animationFrames, TimeSpan delayMs)
        {
            // Set the animation frames and delay.
            AnimationFrames = animationFrames;
            DelayMs = delayMs;
        }
    }
}
