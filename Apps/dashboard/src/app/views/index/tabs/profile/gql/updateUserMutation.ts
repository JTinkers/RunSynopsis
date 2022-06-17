export const updateUserMutation = `mutation ($userId: ID!, $request: UpdateUserRequestInput!) {
	auth_updateUser(userId: $userId, request: $request)
}`