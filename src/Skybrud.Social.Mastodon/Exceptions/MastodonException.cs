using System;

namespace Skybrud.Social.Mastodon.Exceptions {

    /// <summary>
    /// Class representing a basic Mastodon exception.
    /// </summary>
    public class MastodonException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public MastodonException(string message) : base(message) { }

    }

}