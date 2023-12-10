using System.Net;

namespace ParcelLocker.Shared.Abstractions.Exceptions;

public record ErrorResponse(HttpStatusCode StatusCode, object Error);