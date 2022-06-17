export const getArticlesQuery = `query($first: Int, $last: Int, $after: String, $before: String) {
	response: content_getArticles(
		first: $first
		last: $last
		after: $after
		before: $before
		order: { writtenAt: DESC }
	) {
		articles: nodes {
			id
            headerSrc
			title
			slug
			synopsis
			category {
				id
				name
			}
			tags {
				id
				name
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