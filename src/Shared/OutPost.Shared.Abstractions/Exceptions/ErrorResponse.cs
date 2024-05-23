using System.Net;

namespace OutPost.Shared.Abstractions.Exceptions;

public record ErrorResponse(HttpStatusCode StatusCode, object Error);
