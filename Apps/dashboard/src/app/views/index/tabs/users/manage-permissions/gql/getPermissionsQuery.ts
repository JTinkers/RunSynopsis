export const getPermissionsQuery = `query {
	permissions: auth_getPermissions {
		type
		value
	}
}`