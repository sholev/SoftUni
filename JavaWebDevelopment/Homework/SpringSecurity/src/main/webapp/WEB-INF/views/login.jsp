<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
	<head>
		<meta charset="UTF-8">
		<title>Login</title>
	</head>
	<body>
		<form action="/lebank/login" method="POST">
			${output} <br>
			<table>
				<tr>
					<td>Username:</td>
					<td><input type="text" name="username" value="${username}"></td>
				</tr>
				<tr>
					<td>Password:</td>
					<td><input type="password" name="password" value="${password}"></td>
				</tr>
			</table>
			<input type="submit" value="Submit">
		</form>
	</body>
</html>