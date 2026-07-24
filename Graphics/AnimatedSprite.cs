using Microsoft.Xna.Framework;
using System;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// Sprite class that represents a visual object created from a texture region with support for animations.
    /// </summary>
    public class AnimatedSprite : Sprite
    {
        // The current animation frame.
        private int _animationFrame;

        // The time since the last animation frame change.
        private TimeSpan _timeSinceAnimationFrameChange;

        // The current animation.
        private Animation _animation = null!;

        // Animation wrapper property.
        public Animation Animation
        {
            get => _animation; // Gets the current animation.
            set
            {
                // Sets the current animation and resets the state variables.
                _animation = value;
                _animationFrame = 0;
                _timeSinceAnimationFrameChange = TimeSpan.Zero;
                TextureRegion = _animation.AnimationFrames[0];
            }
        }

        /// <summary>
        /// Constructor for the animated sprite class.
        /// </summary>
        /// <param name="animation">The initial animation to load into the sprite.</param>
        public AnimatedSprite(Animation animation) : base(animation.AnimationFrames[0])
        {
            // Set the current animation.
            Animation = animation;
        }

        /// <summary>
        /// Updates the state of the animated sprite.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        public void Update(GameTime gameTime)
        {
            // Add the elapsed game time to the time since animation frame change.
            _timeSinceAnimationFrameChange += gameTime.ElapsedGameTime;

            // While the time since animation frame change exceeds the current animation's delay.
            while (_timeSinceAnimationFrameChange >= _animation.Delay)
            {
                // Get the next index in the animation sequence, capped at the count.
                _animationFrame += 1;
                if (_animationFrame >= _animation.AnimationFrames.Count)
                {
                    _animationFrame = 0;
                }

                // Set the sprite's new texture region.
                TextureRegion = _animation.AnimationFrames[_animationFrame];

                // Reset the time since animation frame change using negative delay, which is lag-spike friendly.
                _timeSinceAnimationFrameChange -= _animation.Delay;
            }
        }
    }
}
