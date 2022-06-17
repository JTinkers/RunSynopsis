export const getCategoriesQuery = `query {
	getCategories: content_getCategories {
		categories: nodes {
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