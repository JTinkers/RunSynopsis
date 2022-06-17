export const getAuthorsQuery = `query {
	authors: content_getAuthors {
		id
		nickname
		avatarUrl
		homepageUrl
		bio
	}
}`