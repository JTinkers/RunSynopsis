export const getUsersQuery = `query {
	getUsers: auth_getUsers {
		users: nodes {
			id
			isBanned
			isVerified
			mail
			nickname
			bio
			avatarUrl
			homepageUrl
			permissions {
				type
				value
			}
		}
	}
}`