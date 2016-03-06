<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="sec" uri="http://www.springframework.org/security/tags" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Banking Registry</title>
	</head>
	<body>
		<form method="GET">
			<p> Logged in as <b><sec:authentication property="principal.username" /></b>.</p>
			<p> ${output} </p>
			<c:if test="${not empty displayData}">
				<table>
					<thead>
						<tr>
							<td>Account</td>
							<td>Balance</td>
							<td>Currency</td>
						</tr>
					</thead>				
					<tbody>
						<c:forEach var="data" items="${displayData}">
							<tr>
								<td>${data.accountId}</td>					
								<td>${data.accountBallance}</td>
								<td>${data.accountCurrency}</td>
							</tr>
						</c:forEach>
					</tbody>				
				</table>
			</c:if>
			<input type="submit" value="New Account" formaction="/lebank/newAccount">
			<input type="submit" value="Operation" formaction="/lebank/operation">
			<input type="submit" value="Logout" formaction="/lebank/logout">
		</form>
	</body>
</html>