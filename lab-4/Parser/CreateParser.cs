using Itmo.ObjectOrientedProgramming.Lab4.Parser.ConnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.DisconnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.FileHandlers.FileShowHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers.TreeGotoHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.TreeHandlers.TreeListHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class CreateParser
{
    public IHandler Create()
    {
        var root = new ConnectHandler(
            new ConnectAddressHandler(
                new ConnectAddressModeHandler(
                    new ConnectAddressLocalModeHandler())));

        var fileCopyHandler = new FileCopyHandler(new FileCopyPathsHandler());
        var fileMoveHandler = new FileMoveHandler(new FileMovePathsHandler());
        var fileDeleteHandler = new FileDeleteHandler(new FileDeletePathHandler());
        var fileRenameHandler = new FileRenameHandler(new FileRenamePathHandler());
        var fileShowHandler = new FileShowHandler(new FileShowPathHandler(
            new FileShowPathModeHandler()));
        fileCopyHandler.SetNextExternalHandler(fileDeleteHandler)
            .SetNextExternalHandler(fileRenameHandler)
            .SetNextExternalHandler(fileShowHandler)
            .SetNextExternalHandler(fileMoveHandler);

        IHandler fileRoot = new FileHandler(fileCopyHandler);

        root.SetNextExternalHandler(fileRoot);

        var treeGotoHandler = new TreeGotoHandler(new TreeGotoPathHandler());
        var treeListHandler = new TreeListHandler(new TreeListDepthHandler());
        treeGotoHandler.SetNextExternalHandler(treeListHandler);
        var treeHandler = new TreeHandler(treeGotoHandler);

        root.SetNextExternalHandler(treeHandler);

        var disconnectHandler = new DisconnectHandler();

        root.SetNextExternalHandler(disconnectHandler);

        return root;
    }
}