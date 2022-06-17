export const grantPermissionMutation = `mutation ($userId: ID!, $type: String!, $value: String!) {
	auth_grant(type: $type, userId: $userId, value: $value)
}`