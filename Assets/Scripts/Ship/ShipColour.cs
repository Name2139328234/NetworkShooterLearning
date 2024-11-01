using Mirror;
using UnityEngine;



public class ShipColour : NetworkBehaviour
{
    [SyncVar] private int _colourIndex;



    public override void OnStartClient()
    {
        base.OnStartClient();


    }



    [Server]
    public void SvSetPaint(int colourIndex)
    {
        _colourIndex = colourIndex;
    }



    [Command]
    private void CmdPaint(int colourIndex)
    {
        SvSetPaint(colourIndex);
    }
    [ClientRpc]
    private void RpcPaint(int colourIndex)
    {
        SpriteRenderer[] paintables = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer paintable in paintables)
            paintable.color = ColourIDStorage.Instance.ColourIDs[colourIndex];
    }
}
