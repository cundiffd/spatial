// Copyright © Spatial. All rights reserved.

using Spatial.Networking;

namespace Ignite.Contracts.Options;

/// <summary>
/// A <see cref="ProtocolBuffer"/> for <see cref="NETCOMMAND.NC_CHAR_OPTION_GET_VIDEO_ACK"/>.
/// </summary>
public class PROTO_NC_CHAR_OPTION_GET_VIDEO_ACK : ProtocolBuffer
{
    /// <summary>
    /// Whether or not the request was successful.
    /// </summary>
    public bool bSuccess;

    /// <summary>
    /// Video data.
    /// </summary>
    public PROTO_NC_CHAR_OPTION_VIDEO Data;

    /// <summary>
    /// Deserialize the <see cref="ProtocolBuffer"/>.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public override void Deserialize()
    {
        bSuccess = ReadBoolean();
        Data = Read<PROTO_NC_CHAR_OPTION_VIDEO>();
    }

    /// <summary>
    /// Serialize the <see cref="ProtocolBuffer"/>.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public override void Serialize()
    {
        Write(bSuccess);
        Write(Data);
    }

    /// <summary>
    /// Dispose of the <see cref="ProtocolBuffer"/>.
    /// </summary>
    public override void Dispose()
    {
        Data.Dispose();

        base.Dispose();
    }
}
