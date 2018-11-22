<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
    <html>
      <body>
        <h1>Order Collection</h1>
        <table border="1">
            <tr><th>Name</th><th>Client</th><th>ID</th><th>Tel</th></tr>
            <xsl:for-each select="OrderService/OrderList/Order">
            <tr>
	<td><xsl:value-of select="Name"/></td>
	<td><xsl:value-of select="Client" /></td>
	<td><xsl:value-of select="Id" /></td>
	<td><xsl:value-of select="Tel" /></td>
	<xsl:for-each select="Data/OrderDetails">
	<td><xsl:value-of select="Name" />&#160;&#160;Count:<xsl:value-of select="Count" />&#160;Price:<xsl:value-of select="Price" /></td>
	</xsl:for-each>
             </tr>
             </xsl:for-each>
        </table>
        </body>
    </html>
</xsl:template>
</xsl:stylesheet>