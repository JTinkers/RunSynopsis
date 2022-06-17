export const getPostsQuery = `query ($first: Int, $last: Int, $after: String, $before: String) {
	response: content_getPosts(
		first: $first
		last: $last
		after: $after
		before: $before
		order: { writtenAt: DESC }
	) {
		posts: nodes {
			id
			title
			slug
			writtenAt
			content
			authorId
			author {
				id
				nickname
				avatarUrl
			}
		}
		pageInfo {
			hasNextPage
			hasPreviousPage
			startCursor
			endCursor
		}
	}
}`