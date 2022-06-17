export const getPostQuery = `query ($id: ID!) {
	post: content_getPost(id: $id) {
		title
		content
		updatedAt
		writtenAt
		tags {
			name
		}
		category {
			name
		}
		author {
			id
			nickname
            avatarUrl
		}
	}
}`