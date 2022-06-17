export const searchQuery = `query ($query: String!) {
	articles: content_findArticles(query: $query) {
		id
		title
        slug
	}
	posts: content_findPosts(query: $query) {
		id
		title
        slug
	}
}`