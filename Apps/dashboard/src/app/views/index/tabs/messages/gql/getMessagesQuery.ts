export const getMessagesQuery = `query {
	getMessages: contact_fetch {
		messages: nodes {
			id
			mail
			body
			title
			submittedAt
		}
		pageInfo {
			hasNextPage
			hasPreviousPage
			startCursor
			endCursor
		}
	}
}`