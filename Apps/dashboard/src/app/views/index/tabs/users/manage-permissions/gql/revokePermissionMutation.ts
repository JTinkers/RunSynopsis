export const revokePermissionMutation = `mutation ($userId: ID!, $type: String!, $value: String!) {
	auth_revoke(type: $type, userId: $userId, value: $value)
}`