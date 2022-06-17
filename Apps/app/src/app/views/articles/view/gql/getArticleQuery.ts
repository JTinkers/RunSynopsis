export const getArticleQuery = `query ($id: ID!) {
	article: content_getArticle(id: $id) {
		title
        headerSrc
		content
        synopsis
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