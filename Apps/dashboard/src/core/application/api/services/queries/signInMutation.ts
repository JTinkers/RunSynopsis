export const signInMutation = `mutation($username: String!, $password: String!) {
	signedIn: gateway_signIn(username: $username, password: $password)
}`