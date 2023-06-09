﻿using Microsoft.Extensions.Logging;
using Peasie.Contracts;
using PeasieLib.Models.DTO;

namespace PeasieLib.Interfaces {
    public interface IPeasieApplicationContextService {
        #region Properties
        public ILogger Logger { get; }
        public string? PeasieUrl { get; set; }
        public SessionRequestDTOWrapper? Session { get; set; }
        public string? AuthenticationToken { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? WebHook { get; set; }
        public string? PeasieClientId { get; set; } // email registered in identity
        public string? PeasieClientSecret { get; set; } // password registered in identity  
        #endregion

        #region Service Methods
        public bool GetAuthenticationToken();
        public bool GetSession(UserDTO userDTO);
        #endregion
    }
}
