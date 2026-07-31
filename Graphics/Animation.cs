using System;
using System.Collections.Generic;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// Animation class to represent movement with texture regions.
    /// </summary>
    public class Animation
    {
        // Texture regions to sequence through in the animation.
        public List<TextureRegion> AnimationFrames { get; private set; }

        // Delay between each animation frame in the sequence.
        public TimeSpan Delay { get; private set; }

        /// <summary>
        /// Constructor for the animation class.
        /// </summary>
        /// <param name="animationFrames">List of texture regions representing each animation frame.</param>
        /// <param name="delay">Delay between showing each animation frame.</param>
        public Animation(List<TextureRegion> animationFrames, TimeSpan delay)
        {
            // Set the animation frames and delay.
            AnimationFrames = animationFrames;
            Delay = delay;
        }
    }
}
