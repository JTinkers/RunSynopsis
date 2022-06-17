export const getTagsQuery = `query {
	getTags: content_getTags {
		tags: nodes {
			id
			name
			description
		}
		pageInfo {
			hasNextPage
			hasPreviousPage
			startCursor
			endCursor
		}
	}
}`