<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Banking Registry</title>
	</head>
	<body>
		<form method="POST">
			${output} <br>
			<table>
				<tr>
					<td>Username: </td>
					<td>${username}</td>
				</tr>
				<tr>
					<td>Account Number: </td>
					<td>${accountNumber}</td>
				</tr>
				<tr>
					<td>Account Ballance: </td>
					<td>${accountBallance}</td>
				</tr>
				<tr>
					<td>Account Currency: </td>
					<td>${accountCurrency}</td>
				</tr>			
			</table>
			<input type="submit" value="New Account" formaction="/lebank/newAccount">
			<input type="submit" value="Operation" formaction="/lebank/operation">
		</form>
	</body>
</html>