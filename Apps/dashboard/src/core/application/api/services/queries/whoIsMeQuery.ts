export const whoIsMeQuery = `query {
	whoIsMe: auth_whoIsMe {
        id
        bio
		nickname
        avatarUrl
        homepageUrl
	}
}`