export const getServicesQuery = `query {
	statuses: gateway_getServiceHealthStatuses {
		name
		isAlive
        responseTime
	}
}`