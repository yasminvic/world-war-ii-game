using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
	[Header("Inputs Field")]
	[SerializeField]
	public PlayerDB player;

    async void Awake()
    {
		try
		{
			await UnityServices.InitializeAsync();
		}
		catch (System.Exception ex)
		{

			Debug.LogException(ex);	
		}
    }

	public async void SignIn()
	{
		await SignInWithUsernamePasswordAsync(player.username.text, player.password.text);
	}

    async Task SignInWithUsernamePasswordAsync(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            Debug.Log("SignIn is successful.");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }
}
