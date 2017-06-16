using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Albert.Power.Runtime;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace aPowerLab.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class WPThemeLab : Page10x
	{
		//Field's 

		 

		//File Types 
		string readme,index,page,header,footer,search;
		public WPThemeLab()
		{
			this.InitializeComponent();

			void pages()
			{
				//page.php
				page = @"<?php

get_header(); ?>

	<div id='primary' class='content - area'>
		  < main id = 'main' class='site-main' role='main'>

		<?php
		// Start the loop.
		while (have_posts() ) : the_post();

			// Include the page content template.
			get_template_part( 'content', 'page' );

			// If comments are open or we have at least one comment, load up the comment template.
			if (comments_open() || get_comments_number() ) :
				comments_template();
		endif;

		// End the loop.
		endwhile;
		?>

		</main><!-- .site-main -->
	</div><!-- .content-area -->

<?php get_footer(); ?>";


				//index.php 
				index = "<?php\n\nif(hav_post()):\nwhile(have_post()); the_post();\n\nget_template_part('content');\nendwhile;\nelse:\necho\"Nothing found!\"\n\nendif;\n?>";

				//header.php 
				header = "<!DOCTYPE html>\n<html>\n<title><?php bloginfo(\"name\"); ?> </title>\n\n<?php wp_head(); //Hook for WordpRess ?>\n\n</head>\n<body> ";

				//footer.php 
				footer = "</body>\n\n</html>";



			}
			//Create pages 
			pages();

			
	

		}
	}
}
