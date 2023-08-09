/**********************************************************************************/
/*******************		WStatClassItemIDSchema Js file		*******************/
/**********************************************************************************/
function GoPreviousPage(Tree,Branch,Utf,xLabel){
	self.location.href='WStatClassItemIDSchema.aspx?Tree='+ Esc(Tree ,Utf) + '&Branch=' + Esc(Branch,Utf) +'&xLabel='+ xLabel;	
		return false;
}