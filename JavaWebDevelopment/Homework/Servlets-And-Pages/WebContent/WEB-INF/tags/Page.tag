<jsp:directive.tag language="java" pageEncoding="ISO-8859-1"/>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="ct" tagdir="/WEB-INF/tags" %>
<%@ attribute name="pageName" %>
<%@ attribute name="date" %>
<c:set var="date" value="${(empty date) ? '' : date}" />
<c:set var="pageName" value="${(empty pageName) ? 'Much page such wow.' : pageName}" />

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Page</title>
</head>
<body>
<div><h3>${pageName}</h3></div>
<div><ct:Table/></div>
<div>Version 0.01 <br> ${date}</div>

</body>
</html>